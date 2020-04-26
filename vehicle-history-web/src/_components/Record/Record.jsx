import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';

import './Record.scss';

class Record extends Component {
	constructor(props) {
		super(props);
	}

	render() {
		const { record } = this.props;
		const { index } = this.props;
		const { totalRecords } = this.props;
		const { location } = record;
		return (
			<div className="record__container">
				<div className="record__left">
					<div className="record__content-left">
						{record.timestampStr}
						<br />
						{record.mileage} km
					</div>
				</div>
				<div className="record__center">
					{index > 0 && (
						<div className="record__image-connector record__image-connector--before"></div>
					)}
					<div className="record__image-container">
						<img src={require(`../../_assets/${record.recordTypeId}.svg`)} alt={record.recordTypeStr} />
					</div>
					{index < totalRecords - 1 && (
						<div className="record__image-connector record__image-connector--after"></div>
					)}
				</div>
				<div className="record__right">
					<div className="record__content-right record__content-right--small">
						{record.recordTypeStr}
					</div>
					<div className="record__content-right record__content-right--bold">
						{record.title}
					</div>
					<div className="record__content-right record__content-right--small">
						{record.description}
					</div>
					<div className="record__content-right record__content-right--small record__content-right--bold">
						Placówka: <br />
						{location.name} <br />
						<span dangerouslySetInnerHTML={{__html: location.fullAddress}} />
					</div>
				</div>
			</div>
		);
	}
}

Record.propTypes = {
	record: PropTypes.object,
	index: PropTypes.number,
	totalRecords: PropTypes.number
};

function mapState(state) {
	const { alert } = state;
	return { alert };
}

const actionCreators = {
};

const connectedRecord = connect(mapState, actionCreators)(Record);
export { connectedRecord as Record };