import config from 'config';
import { handleGenericResponse } from './index';

export const vehicleRecordsService = {
	getByVin
};

function getByVin(vin) {
	const requestOptions = {
		method: 'GET',
		headers: { 'Content-Type': 'application/json' }
	};

	return fetch(`${config.apiUrl}/vehiclerecords/byvin/${vin}`, requestOptions).then(handleGenericResponse);
}