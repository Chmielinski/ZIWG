import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { validators } from '../../_helpers';

import { userActions } from '../../_actions';
import './EmployeeAddForm.scss';

class EmployeeAddForm extends React.Component {
	constructor(props) {
		super(props);
		
		this.state = {
			email: '',
			firstName: '',
			lastName: '',
			group: 1,
			sent: false,
			submitted: false
		};
	}

	handleChange = (e) => {
		const { name, value } = e.target;
		this.setState({ [name]: value });
	}

	isValid = (result) => {
		return this.validate(result.email, true) && 
						this.validate(result.lastName) && 
						this.validate(result.firstName);
	}

	validate = (input, email = false) => {
		return email ? validators.emailValidator(input) : validators.alphanumeric(input);
	}

	handleSubmit = (e) => {
		e.preventDefault();
		const result = {
			email: this.state.email,
			firstName: this.state.firstName,
			lastName: this.state.lastName,
			group: this.state.group,
			locationId: this.props.user.locationId
		};
		this.setState({ submitted: true });
		
		if (this.isValid(result)) {
			this.props.addUser(result);
		}
	}

	resolveErrors = (input, isEmail = false) => {
		if (this.state.submitted) {
			if (!input) {
				return <div className="help-block">Pole jest wymagane</div>;
			} else if (!this.validate(input, isEmail)) {
				return <div className="help-block">Nieprawidłowy format danych</div>;
			}
		}
	}

	render() {
		const { email, firstName, lastName, submitted, group } = this.state;
		const { dictionaries } = this.props.dictionaries.dictionariesLocal;
		return (
			<div className="col-md-8 offset-md-2">
				<h2>Kreator dodawania pracownika</h2>
				<form name="form" onSubmit={this.handleSubmit}>
					<div className={'form-group' + (submitted && !email ? ' has-error' : '')}>
						<label htmlFor="email">Adres E-Mail*</label>
						<input type="text" className="form-control" name="email" value={email} onChange={this.handleChange} />
						{
							this.resolveErrors(email, true)
						}
					</div>
					<div className={'form-group' + (submitted && !firstName ? ' has-error' : '')}>
						<label htmlFor="firstName">Imię*</label>
						<input type="text" className="form-control" name="firstName" value={firstName} onChange={this.handleChange} />
						{
							this.resolveErrors(firstName)
						}
					</div>
					<div className={'form-group' + (submitted && !lastName ? ' has-error' : '')}>
						<label htmlFor="lastName">Nazwisko*</label>
						<input type="text" className="form-control" name="lastName" value={lastName} onChange={this.handleChange} />
						{
							this.resolveErrors(lastName)
						}
					</div>
					{
						dictionaries && dictionaries.length && (
							<div className={'form-group' + (submitted && !group ? ' has-error' : '')}>
								<label htmlFor="group">Grupa*</label>
								<select className="form-control" name="group" value={group} onChange={this.handleChange}>
									{dictionaries.filter(x => x.dictionaryTypeId === 3 && x.enumValue !== 3).map((item, index) => {
										return (
											<option key={`group-${index}`} value={item.enumValue}>{item.stringValue}</option>
										);
									})}
								</select>
							</div>
						)
					}
					<div className="form-group">
						<button className="btn btn-primary" type="submit">Dodaj pracownika</button>
					</div>
				</form>
			</div>
		);
	}
}

EmployeeAddForm.propTypes = {
	addUser: PropTypes.func,
	sent: PropTypes.bool,
	dictionaries: PropTypes.object,
	applied: PropTypes.object,
	user: PropTypes.object
};

function mapState(state) {
	const { sent, dictionaries, loading } = state;
	const { user } = state.authentication;
	const { applied } = state.locations;
	return { sent, dictionaries, loading, applied, user };
}

const actionCreators = {
	addUser: userActions.addUser,
};

const connectedEmployeeAddForm = connect(mapState, actionCreators)(EmployeeAddForm);
export { connectedEmployeeAddForm as EmployeeAddForm };