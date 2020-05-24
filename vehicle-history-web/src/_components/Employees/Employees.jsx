import React from 'react';
import PropTypes from 'prop-types';
import { history } from '../../_helpers';
import { connect } from 'react-redux';
import { userActions } from '../../_actions';
import './Employees.scss';

class Employees extends React.Component {
	constructor(props) {
		super(props);	

		this.state = {
			managers: [],
			employees: []
		};
	}

	componentDidMount = () => {
		this.props.getEmployees(this.props.user.locationId);
	}

	getType = (user, dictionaries) => {
		let dictionaryItem = dictionaries.find(x => x.enumValue === user.group && x.dictionaryTypeId === 3);
		return dictionaryItem ? dictionaryItem.stringValue : 'nieznany typ'; 
	}

	getEmployeeTypeNumber = (user, dictionaries) => {
		let dictionaryItem = dictionaries.find(x => x.enumValue === user.group && x.dictionaryTypeId === 3);
		return dictionaryItem ? dictionaryItem.enumValue : 'unknown'; 
	}

	getDisplay = (users, dictionaries) => {
		return (
			<div>
				<h2>{this.getType(users[0], dictionaries)}</h2>
				{
					users.map((user, index) => (
						<div className="application row" key={`user-${() => this.getEmployeeTypeNumber(user, dictionaries)}-${index}`}>
							<div className="col-md-8 application__details">
								<div className="record__content-right record__content-right--bold">
									{user.firstName} {user.lastName}
								</div>
								<div className="record__content-right">
								Email: {user.email}
								</div>
							</div>
							<button type="button" className="btn btn-danger" onClick={() => this.props.disable(user)}>Archiwizuj</button>
						</div>
					))
				}
			</div>
		);
	} 

	render() {
		const { managers, employees } = this.props;
		const { dictionaries } = this.props.dictionaries.dictionariesLocal;
		
		return (
			<div className="col-md-10 offset-md-1">
				<button type="button" className="btn btn-success" onClick={() => history.push('/employee')}>Nowy pracownik</button>
				{
					managers && managers.length > 0 && (
						this.getDisplay(managers, dictionaries)
					)
				}
				{
					employees && employees.length > 0 && (
						this.getDisplay(employees, dictionaries)
					)
				}
			</div>
		);
	}
}

Employees.propTypes = {
	disable: PropTypes.func,
	dictionaries: PropTypes.object,
	getEmployees: PropTypes.func,
	employees: PropTypes.array,
	managers: PropTypes.array,
	user: PropTypes.object
};

function mapState(state) {
	const { dictionaries, loading } = state;
	const { managers, employees } = state.users;
	const { user } = state.authentication;
	return { dictionaries, loading, managers, employees, user };
}

const actionCreators = {
	getEmployees: userActions.getEmployees,
	disable: userActions.disable
};

const connectedEmployees = connect(mapState, actionCreators)(Employees);
export { connectedEmployees as Employees };