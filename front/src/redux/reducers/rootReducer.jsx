import { combineReducers } from 'redux';

import alert from './alertReducer';

const rootReducer = combineReducers({
  alert,
});

export default rootReducer;