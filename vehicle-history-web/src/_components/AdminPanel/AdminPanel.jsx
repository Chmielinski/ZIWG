import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';

class AdminPanel extends React.Component {
	render() {		
		return (
			<div className="col-md-6 col-md-offset-3">
				Panel Administratora
			</div>
		);
	}
}

AdminPanel.propTypes = {
	user: PropTypes.object,
	users: PropTypes.any
};

function mapState(state) {
	const { users, authentication } = state;
	const { user } = authentication;
	return { user, users };
}

const actionCreators = {	
};

const connectedAdminPanel = connect(mapState, actionCreators)(AdminPanel);
export { connectedAdminPanel as AdminPanel };