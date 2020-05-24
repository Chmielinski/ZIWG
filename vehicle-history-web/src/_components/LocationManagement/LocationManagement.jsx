import React from 'react';
import MaskedInput from 'react-text-mask';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { validators } from '../../_helpers';

import { locationsActions } from '../../_actions';
import './LocationManagement.scss';

class LocationManagement extends React.Component {
	constructor(props) {
		super(props);
		
		this.state = {
			line1: '',
			line2: '',
			apartmentNumber: '',
			name: '',
			zipCode: '',
			locationTypeId: 3,
			sent: false,
			submitted: false,
			updated: false
		};
	}

	componentDidMount = () => {
		this.props.getLocationDetails(this.props.user.locationId);
	}

	handleChange = (e) => {
		const { name, value } = e.target;
		this.setState({ [name]: value });
	}

	isValid = (result) => {
		return this.validate(result.line2) && 
						this.validate(result.line1) && 
						(!result.apartmentNumber || this.validate(result.apartmentNumber)) && 
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
			line1: this.state.line1,
			line2: this.state.line2,
			apartmentNumber: this.state.apartmentNumber,
			name: this.state.name,
			zipCode: this.state.zipCode,
			locationTypeId: this.state.locationTypeId,
			id: this.props.user.locationId
		};
		this.setState({ submitted: true });
		
		if (this.isValid(result)) {
			this.props.update(result);
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
		const { line1, line2, name, zipCode, locationTypeId } = this.props.locationDetails;
		this.setState({
			line1: line1,
			line2: line2,
			name: name, 
			zipCode: zipCode,
			locationTypeId: locationTypeId,
			updated: true
		});
	}

	render() {
		const { line1, line2, name, apartmentNumber, zipCode, locationTypeId, submitted, updated } = this.state;
		const { dictionaries } = this.props.dictionaries.dictionariesLocal;
		const { loaded } = this.props;
		if (loaded) {
			if (!updated) {
				this.updateStates();
			}
			return (
				<div className="col-md-8 offset-md-2">
					<h2>Edycja danych placówki</h2>
					<form name="form" onSubmit={this.handleSubmit}>
						<div className={'form-group' + (submitted && !name ? ' has-error' : '')}>
							<label htmlFor="name">Nazwa placówki*</label>
							<input type="text" className="form-control" name="name" value={name} onBlur={this.handleChange} onChange={this.handleChange} />
							{
								this.resolveErrors(name)
							}
						</div>
						<div className={'form-group' + (submitted && !line1 ? ' has-error' : '')}>
							<label htmlFor="line1">Ulica, numer domu*</label>
							<input type="text" className="form-control" name="line1" value={line1} onBlur={this.handleChange} onChange={this.handleChange} />
							{
								this.resolveErrors(line1)
							}
						</div>
						<div className='form-group'>
							<label htmlFor="apartmentNumber">Numer lokalu</label>
							<input type="text" className="form-control" name="apartmentNumber" value={apartmentNumber} onBlur={this.handleChange} onChange={this.handleChange} />
						</div>
						<div className={'form-group' + (submitted && !zipCode ? ' has-error' : '')}>
							<label htmlFor="zipCode">Kod pocztowy*</label>
							<MaskedInput type="text" className="form-control" name="zipCode" value={zipCode} mask={[/\d/, /\d/, '-', /\d/, /\d/, /\d/]} onBlur={this.handleChange} onChange={this.handleChange} />
							{
								this.resolveErrors(zipCode)
							}
						</div>
						<div className={'form-group' + (submitted && !line2 ? ' has-error' : '')}>
							<label htmlFor="line2">Miejscowość*</label>
							<input type="text" className="form-control" name="line2" value={line2} onBlur={this.handleChange} onChange={this.handleChange} />
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
							<button className="btn btn-primary" type="submit">Zatwierdź zmiany</button>
						</div>
					</form>
				</div>
			);
		} else {
			return (
				<div></div>
			);
		}
	}
}

LocationManagement.propTypes = {
	update: PropTypes.func,
	getLocationDetails: PropTypes.func,
	sent: PropTypes.bool,
	dictionaries: PropTypes.object,
	user: PropTypes.object,
	loaded: PropTypes.bool,
	locationDetails: PropTypes.object
};

function mapState(state) {
	const { dictionaries, loading } = state;
	const { applied, loaded, locationDetails, sent } = state.locations;
	const { user } = state.authentication;
	return { sent, dictionaries, loading, user, applied, loaded, locationDetails };
}

const actionCreators = {
	update: locationsActions.update,
	getLocationDetails: locationsActions.getById
};

const connectedLocationManagement = connect(mapState, actionCreators)(LocationManagement);
export { connectedLocationManagement as LocationManagement };