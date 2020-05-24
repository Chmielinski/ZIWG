import { locationsConstants } from '../_constants';

export function locations(state = {}, action) {
	switch (action.type) {
	case locationsConstants.APPLICATION_REQUEST:
		return {
			loading: true
		};
	case locationsConstants.APPLICATION_SUCCESS:
		return {
			applied: true
		};
	case locationsConstants.GET_ALL_APPLICATIONS_REQUEST:
		return {
			loading: true
		};
	case locationsConstants.GET_ALL_APPLICATIONS_SUCCESS:
		return {
			applications: action.applications
		};
	case locationsConstants.REJECT_SUCCESS:
		return {
			applications: action.applications
		};
	case locationsConstants.ACCEPT_SUCCESS:
		return {
			applications: action.applications
		};
	case locationsConstants.GET_ALL_LOCATIONS_SUCCESS:
		return {
			locations: action.locations
		};
	case locationsConstants.DETAILS_SUCCESS: 
		return {
			loaded: true,
			locationDetails: action.location
		};
	default:
		return state;
	}
}