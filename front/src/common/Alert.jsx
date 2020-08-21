import React, { Component } from 'react'
import { connect } from 'react-redux'
import { alertActions } from '../redux/actions/alert.actions';

export class Alert extends Component {

    componentWillReceiveProps(nextProps) {
        nextProps.alerts.alerts.map(alert => {
            if(alert.delay > 0) {
                setTimeout(() => {
                    this.props.clear(alert.id)
                }, alert.delay)
                return null
            }
            return null
        })
    }

    render() {
        const { alerts } = this.props.alerts
        return (
            <div className="alert-container">
                {alerts.map((alert, index) =>
                    <div key={index} className={`alert alert-${alert.type} alert-dismissible fade show`} role="alert">
                        <p dangerouslySetInnerHTML={{__html: alert.message}}></p>
                        <button type="button" className="close" onClick={e => this.props.clear(alert.id)}>
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                )}
            </div>
        )
    }
}

const mapStateToProps = (state) => ({
    alerts: state.alert
})

const mapDispatchToProps = {
    clear: alertActions.clear
}

export default connect(mapStateToProps, mapDispatchToProps)(Alert)
