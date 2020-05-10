import { dictionariesConstants } from '../_constants';

let dictionariesLocal = JSON.parse(localStorage.getItem('dictionaries'));
const initialState = dictionariesLocal ? { dictionariesLocal } : {};

export function dictionaries(state = initialState, action) {
	switch (action.type) {
	case dictionariesConstants.GETALL_REQUEST:
		return {
			dictionaries: action.dictionaries, date: new Date().getTime()
		};
	case dictionariesConstants.GETALL_SUCCESS:
		return {
			dictionaries: action.dictionaries, date: new Date().getTime()
		};
	default:
		return state;
	}
}