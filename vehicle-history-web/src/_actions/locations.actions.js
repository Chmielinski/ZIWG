import { locationsConstants } from '../_constants';
import { locationsService } from '../_services';
import { alertActions } from './alert.actions';

export const locationsActions = {
	sendApplication,
	getApplications,
	acceptApplication,
	rejectApplication,
	getLocations,
	getById,
	update
};

function sendApplication(applicationParams) {
	return dispatch => {
		dispatch(request(applicationParams));

		locationsService.createApplication(applicationParams)
			.then(
				() => dispatch(success(applicationParams)),
				error => dispatch(alertActions.error(error.toString()))
			);		
	};

	function request(applicationParams) { return { type: locationsConstants.APPLICATION_REQUEST, applicationParams }; }
	function success(applicationParams) { return { type: locationsConstants.APPLICATION_SUCCESS, applicationParams }; }
}

function getApplications() {
	return dispatch => {
		dispatch(request());

		locationsService.getAllApplications()
			.then(
				applications => dispatch(success(applications)),
				error => dispatch(failure(error.toString()))
			);		
	};

	function request() { return { type: locationsConstants.GET_ALL_APPLICATIONS_REQUEST}; }
	function success(applications) { return { type: locationsConstants.GET_ALL_APPLICATIONS_SUCCESS, applications }; }
	function failure(error) { return { type: locationsConstants.GET_ALL_APPLICATIONS_FAILURE, error }; }
}

function getLocations() {
	return dispatch => {
		dispatch(request());

		locationsService.getAllLocations()
			.then(
				locations => dispatch(success(locations)),
				error => dispatch(failure(error.toString()))
			);		
	};

	function request() { return { type: locationsConstants.GET_ALL_LOCATIONS_REQUEST}; }
	function success(locations) { return { type: locationsConstants.GET_ALL_LOCATIONS_SUCCESS, locations }; }
	function failure(error) { return { type: locationsConstants.GET_ALL_LOCATIONS_FAILURE, error }; }
}

function acceptApplication(applicationId) {
	return dispatch => {
		dispatch(request(applicationId));

		locationsService.accept(applicationId)
			.then(
				applications => dispatch(success(applications)),
				error => dispatch(failure(applicationId, error.toString()))
			);		
	};

	function request(applicationId) { return { type: locationsConstants.ACCEPT_REQUEST, applicationId}; }
	function success(applications) { return { type: locationsConstants.ACCEPT_SUCCESS, applications }; }
	function failure(applicationId, error) { return { type: locationsConstants.ACCEPT_FAILURE, applicationId, error }; }
}

function rejectApplication(applicationId) {
	return dispatch => {
		dispatch(request(applicationId));

		locationsService.reject(applicationId)
			.then(
				applications => dispatch(success(applications)),
				error => dispatch(failure(applicationId, error.toString()))
			);		
	};

	function request(applicationId) { return { type: locationsConstants.REJECT_REQUEST, applicationId}; }
	function success(applications) { return { type: locationsConstants.REJECT_SUCCESS, applications }; }
	function failure(applicationId, error) { return { type: locationsConstants.REJECT_FAILURE, applicationId, error }; }
}

function getById(locationId) {
	return dispatch => {
		dispatch(request(locationId));

		locationsService.getById(locationId)
			.then(
				location => dispatch(success(location)),
				error => dispatch(failure(error.toString()))
			);		
	};

	function request(locationId) { return { type: locationsConstants.DETAILS_REQUEST , locationId }; }
	function success(location) { return { type: locationsConstants.DETAILS_SUCCESS, location }; }
	function failure(error) { return { type: locationsConstants.DETAILS_FAILURE, error }; }
}

function update(location) {
	return dispatch => {
		dispatch(request(location));

		locationsService.update(location)
			.then(
				location => {
					dispatch(success(location));
					dispatch(alertActions.success('Zmiany zosta³y zapisane'));
				},
				error => {
					dispatch(failure(location, error.toString()));
					dispatch(alertActions.error(error.toString()));
				}
			);		
	};

	function request(location) { return { type: locationsConstants.UPDATE_REQUEST, location}; }
	function success(location) { return { type: locationsConstants.UPDATE_SUCCESS, location }; }
	function failure(location, error) { return { type: locationsConstants.UPDATE_FAILURE, location, error }; }
}