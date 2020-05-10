import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { locationsActions } from '../../_actions';
import './ApplicationsManagement.scss';

class ApplicationsManagement extends React.Component {
	constructor(props) {
		super(props);	

		this.state = {
			applications: []
		};
	}

	componentDidMount = () => {
		this.props.getApplications();
	}

	getType = (application, dictionaries) => {
		let dictionaryItem = dictionaries.find(x => x.enumValue === application.locationTypeId && x.dictionaryTypeId === 2);
		return dictionaryItem ? dictionaryItem.stringValue : 'nieznany typ'; 
	}

	render() {
		const { applications } = this.props;
		const { dictionaries } = this.props.dictionaries.dictionariesLocal;
		
		return (
			<div className="col-md-10 offset-md-1">
				<h2>
					Aktywne zgłoszenia placówek
				</h2>
				{
					applications && applications.length && (
						applications.map((application, index) => (
							<div className="application row" key={`application-${index}`}>
								<div className="col-md-8 application__details">
									<div className="record__content-right record__content-right--bold">
										Nazwa placówki: {application.name}
									</div>
									<div className="record__content-right">
										Email: {application.email}
									</div>
									<div className="record__content-right record__content-right--small">
										Typ: {this.getType(application, dictionaries)}
									</div>
									<div className="record__content-right record__content-right--small record__content-right--bold">
										Adres: <span dangerouslySetInnerHTML={{__html: application.fullAddress}} />
									</div>
								</div>
								<button type="button" className="btn btn-success" onClick={() => this.props.accept(application.id)}>Zatwierdź</button>
								<button type="button" className="btn btn-danger" onClick={() => this.props.reject(application.id)}>Odrzuć</button>
							</div>
						))
					)
				}
			</div>
		);
	}
}

ApplicationsManagement.propTypes = {
	accept: PropTypes.func,
	reject: PropTypes.func,
	sent: PropTypes.bool,
	dictionaries: PropTypes.object,
	getApplications: PropTypes.func,
	applications: PropTypes.array
};

function mapState(state) {
	const { dictionaries } = state;
	const { applications } = state.locations;
	const { loading } = state;
	return { dictionaries, loading, applications };
}

const actionCreators = {
	accept: locationsActions.acceptApplication,
	reject: locationsActions.rejectApplication,
	getApplications: locationsActions.getApplications
};

const connectedApplicationsManagement = connect(mapState, actionCreators)(ApplicationsManagement);
export { connectedApplicationsManagement as ApplicationsManagement };