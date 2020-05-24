import { userConstants } from '../_constants';
import { userService } from '../_services';
import { alertActions } from './';
import { history } from '../_helpers';

export const userActions = {
	login,
	logout,
	register,
	getAll,
	delete: _delete,
	getEmployees,
	disable,
	addUser,
	update,
	verifyUserIntegrity,
	verifyPassword
};

function login(username, password) {
	return dispatch => {
		dispatch(request({ username }));

		userService.login(username, password)
			.then(
				user => { 
					dispatch(success(user));
					history.push('/');
				},
				error => {
					dispatch(failure(error.toString()));
					dispatch(alertActions.error(error.toString()));
				}
			);
	};

	function request(user) { return { type: userConstants.LOGIN_REQUEST, user }; }
	function success(user) { return { type: userConstants.LOGIN_SUCCESS, user }; }
	function failure(error) { return { type: userConstants.LOGIN_FAILURE, error }; }
}

function logout() {
	userService.logout();
	return { type: userConstants.LOGOUT };
}

function register(user) {
	return dispatch => {
		dispatch(request(user));

		userService.register(user)
			.then(
				() => { 
					dispatch(success());
					history.push('/login');
					dispatch(alertActions.success('Registration successful'));
				},
				error => {
					dispatch(failure(error.toString()));
					dispatch(alertActions.error(error.toString()));
				}
			);
	};

	function request(user) { return { type: userConstants.REGISTER_REQUEST, user }; }
	function success(user) { return { type: userConstants.REGISTER_SUCCESS, user }; }
	function failure(error) { return { type: userConstants.REGISTER_FAILURE, error }; }
}

function getAll() {
	return dispatch => {
		dispatch(request());

		userService.getAll()
			.then(
				users => dispatch(success(users)),
				error => dispatch(failure(error.toString()))
			);
	};

	function request() { return { type: userConstants.GETALL_REQUEST }; }
	function success(users) { return { type: userConstants.GETALL_SUCCESS, users }; }
	function failure(error) { return { type: userConstants.GETALL_FAILURE, error }; }
}

// prefixed function name with underscore because delete is a reserved word in javascript
function _delete(id) {
	return dispatch => {
		dispatch(request(id));

		userService.delete(id)
			.then(
				() => dispatch(success(id)),
				error => dispatch(failure(id, error.toString()))
			);
	};

	function request(id) { return { type: userConstants.DELETE_REQUEST, id }; }
	function success(id) { return { type: userConstants.DELETE_SUCCESS, id }; }
	function failure(id, error) { return { type: userConstants.DELETE_FAILURE, id, error }; }
}

function verifyUserIntegrity() {
	return dispatch => {
		dispatch(request());

		userService.verifyUserIntegrity()
			.then(
				() => dispatch(success()),
				error => {
					dispatch(failure(error.toString()));
					dispatch(userActions.logout());
				}
			);
	};

	function request() { return { type: userConstants.VERIFY_REQUEST }; }
	function success() { return { type: userConstants.VERIFY_SUCCESS }; }
	function failure(error) { return { type: userConstants.VERIFY_FAILURE, error }; }
}

function getEmployees(locationId) {
	return dispatch => {
		dispatch(request(locationId));

		userService.getEmployeesByLocation(locationId)
			.then(
				employees => dispatch(success(employees)),
				error => dispatch(failure(error.toString()))
			);		
	};

	function request(locationId) { return { type: userConstants.GET_EMPLOYEES_REQUEST, locationId}; }
	function success(employees) { return { type: userConstants.GET_EMPLOYEES_SUCCESS, employees }; }
	function failure(error) { return { type: userConstants.GET_EMPLOYEES_FAILURE, error }; }
}

function disable(user) {
	return dispatch => {
		dispatch(request(user));

		userService.disable(user)
			.then(
				(employees) => dispatch(success(employees)),
				error => dispatch(failure(error.toString()))
			);		
	};

	function request(user) { return { type: userConstants.DISABLE_REQUEST, user}; }
	function success(employees) { return { type: userConstants.DISABLE_SUCCESS, employees }; }
	function failure(error) { return { type: userConstants.DISABLE_FAILURE, error }; }
}

function addUser(user) {
	return dispatch => {
		dispatch(request(user));

		userService.addUser(user)
			.then(
				(user) => {
					dispatch(success(user));
					history.push('/employees');
				},
				error => dispatch(failure(error.toString()))
			);		
	};
	
	function request(user) { return { type: userConstants.ADD_USER_REQUEST, user }; }
	function success(employees) { return { type: userConstants.ADD_USER_SUCCESS, employees }; }
	function failure(error) { return { type: userConstants.ADD_USER_FAILURE, error }; }
}

function update(user) {
	return dispatch => {
		dispatch(request(user));

		userService.update(user)
			.then(
				user => {
					dispatch(success(user));
					localStorage.setItem('user', JSON.stringify(user));
					dispatch(alertActions.success('Zmiany zostały zapisane'));
				},
				error => {
					dispatch(failure(location, error.toString()));
					dispatch(alertActions.error(error.toString()));
				}
			);		
	};

	function request(user) { return { type: userConstants.UPDATE_REQUEST, user}; }
	function success(user) { return { type: userConstants.UPDATE_SUCCESS, user }; }
	function failure(user, error) { return { type: userConstants.UPDATE_FAILURE, user, error }; }
}

function verifyPassword(user) {
	return dispatch => {
		dispatch(request(user));
		
		userService.verifyPassword(user)
			.then(
				user => {
					dispatch(success(user));
					dispatch(userActions.update(user));
				},
				error => {
					dispatch(failure(location, error.toString()));
					dispatch(alertActions.error(error.toString()));
				}
			);		
	};

	function request(user) { return { type: userConstants.CHECK_PASSWORD_REQUEST, user}; }
	function success(user) { return { type: userConstants.CHECK_PASSWORD_SUCCESS, user }; }
	function failure(user, error) { return { type: userConstants.CHECK_PASSWORD_FAILURE, user, error }; }
}