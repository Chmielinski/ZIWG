import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { validators } from '../../_helpers';

import { userActions } from '../../_actions';
import './Profile.scss';

class Profile extends React.Component {
	constructor(props) {
		super(props);
		
		this.state = {
			email: '',
			firstName: '',
			lastName: '',
			currentPassword: '',
			newPassword: '',
			repeatNewPassword: '',
			sent: false,
			submitted: false
		};
	}

	componentDidMount = () => {
		this.updateStates();
	}

	handleChange = (e) => {
		const { name, value } = e.target;
		this.setState({ [name]: value });
	}

	isValid = (result) => {
		return this.validate(result.email, true) && 
						this.validate(result.firstName) && 
						this.validate(result.lastName) &&
						((this.state.currentPassword && !this.state.newPassword && !this.state.repeatNewPassword) ||
						(this.validate(this.state.currentPassword) && this.validate(this.state.newPassword) && this.validate(this.state.repeatNewPassword)));
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
			oldPassword: this.state.currentPassword,
			password: this.state.newPassword,
			id: this.props.user.id,
			group: this.props.user.group,
			locationId: this.props.user.locationId,
			token: this.props.user.token
		};
		this.setState({ submitted: true });
		
		if (this.isValid(result)) {
			if (result.oldPassword) {
				this.props.verifyPassword(result);
			} else {
				this.props.update(result);
			}
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

	updateStates = () => {
		const { email, firstName, lastName } = this.props.user;
		this.setState({
			email: email,
			firstName: firstName,
			lastName: lastName, 
			updated: true
		});
	}

	resolvePasswordErrors = (fieldValue) => {
		if (this.state.newPassword && this.state.repeatNewPassword && this.state.currentPassword || fieldValue) {
			return;
		}
		if (this.state.newPassword && this.state.repeatNewPassword && !this.state.currentPassword) {
			return <div className="help-block">Aby zmienić hasło musisz wprowadzić obecne</div>;
		} else if (this.state.newPassword || this.state.repeatNewPassword) {
			return <div className="help-block">Aby zmienić hasło musisz wypełnić to pole</div>;
		}
	}

	render() {
		const { email, firstName, lastName, currentPassword, newPassword, repeatNewPassword, submitted } = this.state;
		return (
			<div className="col-md-8 offset-md-2">
				<h2>Edycja profilu</h2>
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
					<div className={'form-group' + (submitted && !currentPassword ? ' has-error' : '')}>
						<label htmlFor="lastName">Obecne hasło</label>
						<input type="password" className="form-control" name="currentPassword" value={currentPassword} onChange={this.handleChange} />
						{
							this.resolvePasswordErrors(currentPassword)
						}
					</div>
					<div className={'form-group' + (submitted && !newPassword ? ' has-error' : '')}>
						<label htmlFor="lastName">Nowe hasło</label>
						<input type="password" className="form-control" name="newPassword" value={newPassword} onChange={this.handleChange} />
						{
							this.resolvePasswordErrors(newPassword)
						}
					</div>
					<div className={'form-group' + (submitted && !repeatNewPassword ? ' has-error' : '')}>
						<label htmlFor="lastName">Powtórz nowe hasło</label>
						<input type="password" className="form-control" name="repeatNewPassword" value={repeatNewPassword} onChange={this.handleChange} />
						{
							this.resolvePasswordErrors(repeatNewPassword)
						}
					</div>
					<div className="form-group">
						<button className="btn btn-primary" type="submit">Zatwierdź zmiany</button>
					</div>
				</form>
			</div>
		);
	}
}

Profile.propTypes = {
	verifyPassword: PropTypes.func,
	update: PropTypes.func,
	user: PropTypes.object,
	ready: PropTypes.bool
};

function mapState(state) {
	const { loading } = state;
	const { ready } = state.users;
	const { user } = state.authentication;
	return { loading, user, ready };
}

const actionCreators = {
	verifyPassword: userActions.verifyPassword,
	update: userActions.update
};

const connectedProfile = connect(mapState, actionCreators)(Profile);
export { connectedProfile as Profile };