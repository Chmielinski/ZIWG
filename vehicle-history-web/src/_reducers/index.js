import { combineReducers } from 'redux';

import { authentication } from './authentication.reducer';
import { users } from './users.reducer';
import { alert } from './alert.reducer';
import { dictionaries } from './dictionaries.reducer';
import { locations } from './locations.reducer';

const rootReducer = combineReducers({
	authentication,
	users,
	alert,
	dictionaries,
	locations
});

export default rootReducer;