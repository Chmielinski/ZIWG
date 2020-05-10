import config from 'config';
import { authHeader } from '../_helpers';
import { handleAuthResponse } from './user.service';
import { handleGenericResponse } from '.';

export const locationsService = {
	createApplication,
	getAllApplications,
	getAllLocations,
	accept,
	reject,
	getById,
	update
};

function createApplication(applicationParams) {
	const requestOptions = {
		method: 'POST',
		headers: { 'Content-Type': 'application/json' },
		body: JSON.stringify(applicationParams)
	};

	return fetch(`${config.apiUrl}/locations/add`, requestOptions).then(handleGenericResponse);
}

function getAllApplications() {
	const requestOptions = {
		method: 'GET',
		headers: authHeader()
	};

	return fetch(`${config.apiUrl}/locations/applications`, requestOptions).then(handleAuthResponse);
}

function accept(applicationId) {
	const requestOptions = {
		method: 'PUT',
		headers: authHeader(),
	};

	return fetch(`${config.apiUrl}/locations/accept/${applicationId}`, requestOptions).then(handleAuthResponse).then(getAllApplications());
}

function reject(applicationId) {
	const requestOptions = {
		method: 'PUT',
		headers: authHeader(),
	};

	return fetch(`${config.apiUrl}/locations/reject/${applicationId}`, requestOptions).then(handleAuthResponse);
}

	return fetch(`${config.apiUrl}/locations/${location.id}`, requestOptions).then(handleAuthResponse);
}