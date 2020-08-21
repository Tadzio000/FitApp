export const alertConstants = {
    SUCCESS: 'ALERT_SUCCESS',
    WARN: 'ALERT_WARN',
    ERROR: 'ALERT_ERROR',
    INFO: 'ALERT_INFO',
    CLEAR: 'ALERT_CLEAR'
  }
  

const initialState = {
    alerts: [],
}

export default function alert(state = initialState, { type, payload }) {

    switch(type) {
        case alertConstants.SUCCESS:
            state.alerts.push(payload)
            return {...state}
        case alertConstants.WARN:
            state.alerts.push(payload)
            return {...state}
        case alertConstants.ERROR:
            state.alerts.push(payload)
            return {...state}
        case alertConstants.INFO:
            state.alerts.push(payload)
            return {...state}
        case alertConstants.CLEAR:
            state.alerts = state.alerts.filter(alert => alert.id !== payload.index)
            return {...state}
        default:
            return state
    }
}