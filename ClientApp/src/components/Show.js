import React from 'react'
import { Link } from 'react-router-dom'

export default () => (
    <div className="container mainHeader">
        <div className="maintitle">Academy Award </div>
        <div className="maintitle">Winning Actresses</div>
        <Link to="/total">
            <button className="btn btn-primary showActressButton">Show Actresses</button>
        </Link>
    </div>
)


