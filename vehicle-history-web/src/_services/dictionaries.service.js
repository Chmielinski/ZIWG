import config from 'config';
import { handleGenericResponse } from '.';

export const dictionariesService = {
	getAll
};

function getAll() {
	const requestOptions = {
		method: 'GET',
		headers: { 'Content-Type': 'application/json' }
	};

	return fetch(`${config.apiUrl}/dictionaries`, requestOptions)
		.then(handleGenericResponse)
		.then(dictionaries => {
			localStorage.setItem('dictionaries', JSON.stringify({dictionaries: dictionaries, date: new Date().getTime()}));
			return dictionaries;
		});
}
