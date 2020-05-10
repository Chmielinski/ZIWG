import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { navigationActions } from '../../_helpers';

import { userActions } from '../../_actions';
import './header.scss';

class Header extends Component {
	constructor(props) {
		super(props);
	}

	navigate = (page) => {
		if (!this.props.activeRoute.startsWith(page)) {
			navigationActions.navigateTo(page);
		}
	}

	isCurrent = (page) => {
		return this.props.activeRoute.startsWith(page);
	}

	getNavigationOptions = () => {
		const { user } = this.props;
		if (!user) {
			return <div className={`header__menu-item header__menu-item--right ${this.isCurrent('/apply') ? 'header__menu-item--current' : ''}`} onClick={() => this.navigate('/apply')}>Dołącz do systemu</div>;
		}
		if (user.group === 3) {
			return (
				<div className="header__menu">
					<div className={`header__menu-item ${this.isCurrent('/profile') ? 'header__menu-item--current' : ''}`} onClick={() => this.navigate('/profile')}>Profil</div>
					<div className={`header__menu-item ${this.isCurrent('/applications') ? 'header__menu-item--current' : ''}`} onClick={() => this.navigate('/applications')}>Zgłoszenia</div>
					<div className={`header__menu-item ${this.isCurrent('/profile') ? 'header__menu-item--current' : ''}`} onClick={() => this.navigate('/profile')}>Profil</div>
					<div className="header__menu-item header__menu-item--right" onClick={this.props.logout}>Wyloguj</div>
				</div>
			);
		} else if (user.group == 2) {
			return (
				<div className="header__menu">
					<div className={`header__menu-item ${this.isCurrent('/profile') ? 'header__menu-item--current' : ''}`} onClick={() => this.navigate('/profile')}>Profil</div>
					<div className="header__menu-item header__menu-item--right" onClick={this.props.logout}>Wyloguj</div>
				</div>
			);
		} else {
			return (
				<div className="header__menu-item header__menu-item--right" onClick={this.props.logout}>Wyloguj</div>
			);
		}
	}
	render() {
		return (
			<div className="header header__menu">
				<Link className="header__main header__menu-item" to="/">Vehicle History</Link>
				{
					this.getNavigationOptions()
				}
			</div>
		);
	}
}

Header.propTypes = {
	logout: PropTypes.func,
	user: PropTypes.object,
	activeRoute: PropTypes.string
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