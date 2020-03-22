import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

class HomePage extends React.Component {
	constructor(props) {
		super(props);
	}

	render() {
		return (
			<div className="container">
				Hello World
			</div>
		);
	}
}

HomePage.propTypes = {
	alert: PropTypes.object,
	clearAlerts: PropTypes.func
};

function mapState(state) {
	const { alert } = state;
	return { alert };
}

const actionCreators = {
};

const connectedHomePage = connect(mapState, actionCreators)(HomePage);
export { connectedHomePage as HomePage };