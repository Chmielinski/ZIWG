import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';

import { Record } from '../Record';
import { vehicleRecordsService } from '../../_services';

import loadingGif from '../../_assets/loading.gif';
import './Report.scss';

class Report extends Component {
	constructor(props) {
		super(props);

		this.state = {
			loading: true,
			records: []
		};
	}

	componentDidMount = () => {
		vehicleRecordsService.getByVin(this.props.match.params.vin).then(records => {
			this.setState({ loading: false, records: records});
		});
	}

	render() {
		const { records, loading } = this.state;
		return (
			<div className="report">
				{
					loading && (
						<div className="report__loading">
							<img src={loadingGif} alt="loading" />
						</div>
					)
				}
				{
					!loading && records.length === 0 && (
						<h3 className="report__not-found">
							Brak danych dla podanego numeru VIN. Upewnij się, że wprowadzony numer VIN jest poprawny.
						</h3>
					)
				}
				{
					!loading && records.length > 0 && (
						<div>
							{records.map((record, index) => (
								<div key={`record-${index}`}>
									<Record record={record} index={index} totalRecords={records.length}/>
								</div>	
							))}
						</div>
					)
				}
			</div>
		);
	}
}

Report.propTypes = {
	alert: PropTypes.object,
	clearAlerts: PropTypes.func,
	match: PropTypes.object
};

function mapState(state) {
	const { alert } = state;
	return { alert };
}

const actionCreators = {
};

const connectedReport = connect(mapState, actionCreators)(Report);
export { connectedReport as Report };