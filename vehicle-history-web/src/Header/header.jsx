import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

import { userActions } from '../_actions';

class Header extends Component {
	constructor(props) {
		super(props);
	}

	render() {
		const { user } = this.props;
		console.log(this.props);
		return (
			<nav className="navbar navbar-expand-sm bg-dark navbar-dark">
				<Link className="navbar-brand" to="/">Vehicle History</Link>
				{
					user && (
						<div className="nav-item" onClick={this.props.logout}>Wyloguj</div>
					)
				}
			</nav>
		);
	}
}

Header.propTypes = {
	logout: PropTypes.func,
	user: PropTypes.object
};


function mapState(state) {
	const { user } = state.authentication;
	return { user };
}

const actionCreators = {
	logout: userActions.logout
};

const connectedHeader = connect(mapState, actionCreators)(Header);
export { connectedHeader as Header };