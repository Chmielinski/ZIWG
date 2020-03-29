import { createBrowserHistory } from 'history';

export const history = createBrowserHistory();

export const navigationActions = {
	navigateTo
};

function navigateTo(page, param = null) {
	if (param) {
		history.push(`${page}/${param}`);
	} else {
		history.push(`${page}`);
	}
}