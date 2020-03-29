import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { history } from '../../_helpers';
import './HomePage.scss';

class HomePage extends Component {
	constructor(props) {
		super(props);

		this.state = {
			vin: '',
			submitted: false
		};
	}

	handleChange = (e) => {
		const { name, value } = e.target;
		this.setState({ [name]: value });
	}

	handleSubmit = (e) => {
		e.preventDefault();

		this.setState({ submitted: true });
		const { vin } = this.state;
		if (vin) {
			//TODO: get report
		}
	}

	render() {
		const { vin, submitted } = this.state;
		return (
			<form className="homepage__form form" onSubmit={this.handleSubmit}>
				<div className={'form-group' + (submitted && !vin ? ' has-error' : '')}>
					<label htmlFor="vin">Wpisz numer VIN</label>
					<input type="text" className="form-control" name="vin" value={vin} onChange={this.handleChange} />
					{submitted && !vin &&
						<div className="help-block">Vin is required</div>
					}
				</div>
				<div className="form-group">
					<button className="btn btn-primary" type="submit">Generuj raport</button>
				</div>
			</form>
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