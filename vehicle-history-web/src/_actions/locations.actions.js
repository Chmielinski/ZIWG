import { locationsConstants } from '../_constants';
import { locationsService } from '../_services';
import { alertActions } from './alert.actions';

export const locationsActions = {
	sendApplication,
	getApplications,
	acceptApplication,
	rejectApplication
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