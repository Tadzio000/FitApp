import { combineReducers } from 'redux';

import { registration } from './registrationReducer';

const rootReducer = combineReducers({
  registration,
});

export default rootReducer;