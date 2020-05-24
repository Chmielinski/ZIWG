import { alertActions } from '../_actions';

export * from './user.service';
export * from './dictionaries.service';
export * from './vehicle-records.service';
export * from './locations.service';

export function handleGenericResponse(response) {
	return response.text().then(text => {
		const data = text && JSON.parse(text);
		if (!response.ok) {
			const error = (data && data.message) || response.statusText;
			alertActions.error(data.message);
			return Promise.reject(error);
		}
		return data;
	});
}