import React from 'react';
import { Router, Route, Switch, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { history } from '../_helpers';
import { alertActions, userActions } from '../_actions';
import Header from '../_components/Header';
import Footer from '../_components/Footer';
import { AdminPanel } from '../_components/AdminPanel';
import { LoginPage } from '../_components/LoginPage';
import { HomePage } from '../_components/HomePage';
import { Profile } from '../_components/Profile';
import './App.scss';

class App extends React.Component {
	constructor(props) {
		super(props);

		this.state = {
			currentPath: '/'
		};

		history.listen(() => {
			if (localStorage.getItem('user') && localStorage.getItem('user') !== 'null') {
				this.props.verifyUserIntegrity();
			}
			// clear alert on location change
			this.props.clearAlerts();
			this.setState({currentPath: window.location.pathname});
		});
	}

	render() {
		const { alert } = this.props;
		const user = JSON.parse(localStorage.getItem('user'));
		return (
			<Router history={history}>
				<div>
					<Header activeRoute={this.state.currentPath} />
					<div className="container">
						{alert.message &&
								<div className={`alert ${alert.type}`}>{alert.message}</div>
						}
						<Switch>
						<Route exact path="/admin-panel" render={() => user && user.group === 3 ? <AdminPanel /> : <Redirect to="/" />} />
							<Route path="/profile" render={() => user && (user.group === 2 || user.group === 3) ? <Profile /> : <Redirect to="/" />} />
							<Route path="/login" component={LoginPage} />
							<Route exact path="/" component={HomePage} />
							<Redirect from="*" to="/" />
						</Switch>
					</div>
					<Footer />
				</div>
			</Router>
		);
	}
}

App.propTypes = {
	alert: PropTypes.object,
	clearAlerts: PropTypes.func,
	verifyUserIntegrity: PropTypes.func
};

function mapState(state) {
	const { alert } = state;
	return { alert };
}

const actionCreators = {
	clearAlerts: alertActions.clear,
	verifyUserIntegrity: userActions.verifyUserIntegrity
};

const connectedApp = connect(mapState, actionCreators)(App);
export { connectedApp as App };