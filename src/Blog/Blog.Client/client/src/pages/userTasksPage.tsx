import React from "react";
import { RouteComponentProps } from "react-router-dom";
import { IUserTasksParams } from "../shared/interfaces";

interface IProps extends RouteComponentProps<IUserTasksParams> {}; 

export const UserTasksPage: React.FC<IProps> = ({match} : IProps) => {
    return (
        <div>
            <h1>User Tasks Page</h1>
            <p>{match.params.shortName}</p>
        </div>
    );
}