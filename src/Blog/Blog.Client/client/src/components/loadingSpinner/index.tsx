import React from "react";

import Spinner from "react-bootstrap/Spinner";

export const LoadingSpinner = () => {
    return (
        <div>
            <Spinner animation="border" role="status">
                <span className="sr-only">Loading...</span> 
            </Spinner>
        </div>
    )
}