import React from 'react';
import { Router, Route, Switch, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { history } from '../_helpers';
import { alertActions } from '../_actions';
import { PrivateRoute } from '../_components';
import Header from '../Header';
import Footer from '../Footer';
import { AdminPanel } from '../AdminPanel';
import { LoginPage } from '../LoginPage';
import { HomePage } from '../HomePage';

class App extends React.Component {
	constructor(props) {
		super(props);

		history.listen(() => {
			// clear alert on location change
			this.props.clearAlerts();
		});
	}

	render() {
		const { alert } = this.props;
		return (
			<Router history={history}>
				<div>
					<Header />
					<div className="container">
						{alert.message &&
								<div className={`alert ${alert.type}`}>{alert.message}</div>
						}
						<Switch>
							<PrivateRoute exact path="/admin-panel" component={AdminPanel} />
							<Route path="/admin" component={LoginPage} />
							<Route path="/" component={HomePage} />
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
	clearAlerts: PropTypes.func
};

function mapState(state) {
	const { alert } = state;
	return { alert };
}

const actionCreators = {
	clearAlerts: alertActions.clear
};

const connectedApp = connect(mapState, actionCreators)(App);
export { connectedApp as App };