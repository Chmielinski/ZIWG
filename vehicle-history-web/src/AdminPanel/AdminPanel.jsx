import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';

class AdminPanel extends React.Component {
	render() {
		const { user, users } = this.props;
		
		return (
			<div className="col-md-6 col-md-offset-3">
				Hello
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