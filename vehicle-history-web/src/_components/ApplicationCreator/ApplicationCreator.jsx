import React from 'react';
import MaskedInput from 'react-text-mask';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { validators } from '../../_helpers';

import { locationsActions } from '../../_actions';
import './ApplicationCreator.scss';

class ApplicationCreator extends React.Component {
	constructor(props) {
		super(props);
		
		this.state = {
			email: '',
			line1: '',
			line2: '',
			apartmentNumber: '',
			name: '',
			zipCode: '',
			locationTypeId: 3,
			sent: false
		};
	}

	handleChange = (e) => {
		const { name, value } = e.target;
		this.setState({ [name]: value });
	}

	isValid = (result) => {
		return this.validate(result.email, true) && 
						this.validate(result.line2) && 
						this.validate(result.line1) && 
						this.validate(result.name) && 
						this.validate(result.zipCode) && 
						this.validate(result.locationTypeId);
	}

	validate = (input, email = false) => {
		return email ? validators.emailValidator(input) : validators.alphanumeric(input);
	}

	handleSubmit = (e) => {
		e.preventDefault();
		const result = {
			email: this.state.email,
			line1: this.state.line1,
			line2: this.state.line2,
			apartmentNumber: this.state.apartmentNumber,
			name: this.state.name,
			zipCode: this.state.zipCode,
			locationTypeId: this.state.locationTypeId,
			status: 0
		};
		this.setState({ submitted: true });
		
		if (this.isValid(result)) {
			this.props.send(result);
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
		const { email, line1, line2, apartmentNumber, name, zipCode, locationTypeId, submitted } = this.state;
		const { dictionaries } = this.props.dictionaries.dictionariesLocal;
		const { applied } = this.props;
		if (!applied) {
			return (
				<div className="col-md-8 offset-md-2">
					<h2>Kreator zgłoszenia placówki do systemu</h2>
					<form name="form" onSubmit={this.handleSubmit}>
						<div className={'form-group' + (submitted && !email ? ' has-error' : '')}>
							<label htmlFor="email">Adres E-Mail*</label>
							<input type="text" className="form-control" name="email" value={email} onChange={this.handleChange} />
							{
								this.resolveErrors(email, true)
							}
						</div>
						<div className={'form-group' + (submitted && !name ? ' has-error' : '')}>
							<label htmlFor="name">Nazwa placówki*</label>
							<input type="text" className="form-control" name="name" value={name} onChange={this.handleChange} />
							{
								this.resolveErrors(name)
							}
						</div>
						<div className={'form-group' + (submitted && !line1 ? ' has-error' : '')}>
							<label htmlFor="line1">Ulica, numer domu*</label>
							<input type="text" className="form-control" name="line1" value={line1} onChange={this.handleChange} />
							{
								this.resolveErrors(line1)
							}
						</div>
						<div className='form-group'>
							<label htmlFor="apartmentNumber">Numer lokalu</label>
							<input type="text" className="form-control" name="apartmentNumber" value={apartmentNumber} onChange={this.handleChange} />
						</div>
						<div className={'form-group' + (submitted && !zipCode ? ' has-error' : '')}>
							<label htmlFor="zipCode">Kod pocztowy*</label>
							<MaskedInput type="text" className="form-control" name="zipCode" value={zipCode} mask={[/\d/, /\d/, '-', /\d/, /\d/, /\d/]} onChange={this.handleChange} />
							{
								this.resolveErrors(zipCode)
							}
						</div>
						<div className={'form-group' + (submitted && !line2 ? ' has-error' : '')}>
							<label htmlFor="line2">Miejscowość*</label>
							<input type="text" className="form-control" name="line2" value={line2} onChange={this.handleChange} />
							{
								this.resolveErrors(line2)
							}
						</div>
						{
							dictionaries && dictionaries.length && (
								<div className={'form-group' + (submitted && !locationTypeId ? ' has-error' : '')}>
									<label htmlFor="locationTypeId">Typ placówki*</label>
									<select className="form-control" name="locationTypeId" value={locationTypeId} onChange={this.handleChange}>
										{dictionaries.filter(x => x.dictionaryTypeId === 2).map((item, index) => {
											return (
												<option key={`location-type-${index}`} value={item.enumValue}>{item.stringValue}</option>
											);
										})}
									</select>
								</div>
							)
						}
						<div className="form-group">
							<button className="btn btn-primary" type="submit">Wyślij zgłoszenie</button>
						</div>
					</form>
				</div>
			);
		} else {
			return (
				<div className="col-md-10 offset-md-1 center-vertically">
					<h2>
						Dziękujemy za zgłoszenie placówki. O wyniku rozpatrzenia zgłoszenia zostaniesz poinformowany pocztą elektoniczną.
					</h2>
				</div>
			);
		}
	}
}

ApplicationCreator.propTypes = {
	send: PropTypes.func,
	sent: PropTypes.bool,
	dictionaries: PropTypes.object,
	applied: PropTypes.object
};

function mapState(state) {
	const { sent } = state;
	const { dictionaries } = state;
	const { applied } = state.locations;
	const { loading } = state;
	return { sent, dictionaries, loading, applied };
}

const actionCreators = {
	send: locationsActions.sendApplication,
};

const connectedApplicationCreator = connect(mapState, actionCreators)(ApplicationCreator);
export { connectedApplicationCreator as ApplicationCreator };