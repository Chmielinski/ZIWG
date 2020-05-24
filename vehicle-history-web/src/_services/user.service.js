import { alertActions } from '../_actions';
import config from 'config';
import { authHeader, history } from '../_helpers';

export const userService = {
	login,
	logout,
	create,
	getAll,
	getById,
	update,
	delete: _delete,
	verifyUserIntegrity,
	getEmployeesByLocation,
	disable,
	addUser,
	verifyPassword
};

function login(email, password) {
	const requestOptions = {
		method: 'POST',
		headers: { 'Content-Type': 'application/json' },
		body: JSON.stringify({ email, password })
	};

	return fetch(`${config.apiUrl}/users/authenticate`, requestOptions)
		.then(handleAuthResponse)
		.then(user => {
			localStorage.setItem('user', JSON.stringify(user));

			return user;
		});
}

function logout(returnHome = true) {
	if (authHeader()) {
		const requestOptions = {
			method: 'POST',
			headers: authHeader()
		};
	
		return fetch(`${config.apiUrl}/users/logout`, requestOptions)
			.then(localStorage.setItem('user', null))
			.then(returnHome ? history.push('/') : null);
	}
}

function getAll() {
	const requestOptions = {
		method: 'GET',
		headers: authHeader()
	};

	return fetch(`${config.apiUrl}/users`, requestOptions).then(handleAuthResponse);
}

function getById(id) {
	const requestOptions = {
		method: 'GET',
		headers: authHeader()
	};

	return fetch(`${config.apiUrl}/users/${id}`, requestOptions).then(handleAuthResponse);
}

function create(user) {
	const requestOptions = {
		method: 'POST',
		headers: { 'Content-Type': 'application/json' },
		body: JSON.stringify(user)
	};

	return fetch(`${config.apiUrl}/users/create`, requestOptions).then(handleAuthResponse);
}

function update(user) {
	const requestOptions = {
		method: 'PUT',
		headers: { ...authHeader(), 'Content-Type': 'application/json' },
		body: JSON.stringify(user)
	};

	return fetch(`${config.apiUrl}/users/${user.id}`, requestOptions).then(handleAuthResponse);
}

function _delete(id) {
	const requestOptions = {
		method: 'DELETE',
		headers: authHeader()
	};

	return fetch(`${config.apiUrl}/users/${id}`, requestOptions).then(handleAuthResponse);
}

export function handleAuthResponse(response) {
	return response.text().then(text => {
		const data = text && JSON.parse(text);
		if (!response.ok) {
			if (response.status === 401) {
				logout();
			}

			const error = (data && data.message) || response.statusText;
			alertActions.error(data.message);
			return Promise.reject(error);
		}

		return data;
	});
}

function verifyUserIntegrity() {
	const requestOptions = {
		method: 'POST',
		headers: { ...authHeader(), 'Content-Type': 'application/json' },
		body: localStorage.getItem('user')
	};
	
	return fetch(`${config.apiUrl}/users/check`, requestOptions).then(handleAuthResponse);
}

function getEmployeesByLocation(locationId) {
	const requestOptions = {
		method: 'GET',
		headers: authHeader()
	};
	
	return fetch(`${config.apiUrl}/users/employees/${locationId}`, requestOptions).then(handleAuthResponse);
}

function disable(user) {
	const requestOptions = {
		method: 'PUT',
		headers: { ...authHeader(), 'Content-Type': 'application/json' },
		body: JSON.stringify(user)
	};

	return fetch(`${config.apiUrl}/users/disable`, requestOptions).then(handleAuthResponse);
}

function addUser(user) {
	const requestOptions = {
		method: 'POST',
		headers: { ...authHeader(), 'Content-Type': 'application/json' },
		body: JSON.stringify(user)
	};

	return fetch(`${config.apiUrl}/users/add`, requestOptions).then(handleAuthResponse);
}

function verifyPassword(user) {
	const requestOptions = {
		method: 'POST',
		headers: { ...authHeader(), 'Content-Type': 'application/json' },
		body: JSON.stringify(user)
	};
	
	return fetch(`${config.apiUrl}/users/validate-password`, requestOptions).then(handleAuthResponse);
}