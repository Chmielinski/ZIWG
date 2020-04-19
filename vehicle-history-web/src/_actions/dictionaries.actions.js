import { alertActions } from './';
import { dictionariesConstants } from '../_constants';
import { dictionariesService } from '../_services';

export const dictionariesActions = {
	getAll
};

function getAll() {
	return dispatch => {
		dispatch(request());

		dictionariesService.getAll()
			.then(
				dictionaries => { 
					dispatch(success(dictionaries));
				},
				error => {
					dispatch(failure(error.toString()));
					dispatch(alertActions.error(error.toString()));
				}
			);
	};

	function request() { return { type: dictionariesConstants.GETALL_REQUEST }; }
	function success(dictionaries) { return { type: dictionariesConstants.GETALL_SUCCESS, dictionaries }; }
	function failure(error) { return { type: dictionariesConstants.GETALL_FAILURE, error }; }
}