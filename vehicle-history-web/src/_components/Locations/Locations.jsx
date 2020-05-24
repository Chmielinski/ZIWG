import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { locationsActions } from '../../_actions';
import './Locations.scss';

class Locations extends React.Component {
	constructor(props) {
		super(props);	

		this.state = {
			locations: []
		};
	}

	componentDidMount = () => {
		this.props.getLocations();
	}

	getType = (application, dictionaries) => {
		let dictionaryItem = dictionaries.find(x => x.enumValue === application.locationTypeId && x.dictionaryTypeId === 2);
		return dictionaryItem ? dictionaryItem.stringValue : 'nieznany typ'; 
	}

	render() {
		const { locations } = this.props;
		const { dictionaries } = this.props.dictionaries.dictionariesLocal;
		
		return (
			<div className="col-md-10 offset-md-1">
				<h2>
					Placówki zarejestrowane w systemie
				</h2>
				{
					locations && locations.length && (
						locations.map((location, index) => (
							<div className="location row" key={`location-${index}`}>
								<div className="col-md-8 application__details">
									<div className="location__content location__content--bold">
										Nazwa placówki: {location.name}
									</div>
									<div className="location__content">
										Dane Kontaktowe: {
											location.operators.map((operator, opIndex) => (
												<div key={`location-${index}-operator-${opIndex}`} className="location__content--small location__content--bold">
													{operator.firstName} {operator.lastName}, E-Mail: <a href={'mailto:' + operator.email}>{operator.email}</a>
												</div>
											))
										}
									</div>
									<div className="location__content location__content--small">
										Typ: {this.getType(location, dictionaries)}
									</div>
									<div className="location__content location__content--small location__content--bold">
										Adres: <span dangerouslySetInnerHTML={{__html: location.fullAddress}} />
									</div>
								</div>
							</div>
						))
					)
				}
			</div>
		);
	}
}

Locations.propTypes = {
	accept: PropTypes.func,
	reject: PropTypes.func,
	sent: PropTypes.bool,
	dictionaries: PropTypes.object,
	getLocations: PropTypes.func,
	locations: PropTypes.array
};

function mapState(state) {
	const { dictionaries } = state;
	const { locations } = state.locations;
	const { loading } = state;
	return { dictionaries, loading, locations };
}

const actionCreators = {
	getLocations: locationsActions.getLocations
};

const connectedLocations = connect(mapState, actionCreators)(Locations);
export { connectedLocations as Locations };