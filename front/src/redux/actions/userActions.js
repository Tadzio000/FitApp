import { userService } from '../services/userServices';
import { userConstants } from '../constants/userConstants';

export const userActions = {
    register,
};


function register(user) {
    return dispatch => {
        dispatch(request(user));

        userService.register(user)
            .then(
                () => { 
                    dispatch(success());
                    // history.push('/login');
                    // dispatch(alertActions.success('Registration successful'));
                },
                error => {
                    dispatch(failure(error));
                    // dispatch(alertActions.error(error));
                }
            );
    };
    function request(user) { return { type: userConstants.REGISTER_REQUEST, user } }
    function success(user) { return { type: userConstants.REGISTER_SUCCESS, user } }
    function failure(error) { return { type: userConstants.REGISTER_FAILURE, error } }
}