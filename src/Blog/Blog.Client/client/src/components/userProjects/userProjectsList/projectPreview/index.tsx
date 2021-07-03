import React from "react";
import { Link } from "react-router-dom";

import { IUserProjectPreview } from "../../../../shared/interfaces";

interface IProjectPreviewProps {
    obj: IUserProjectPreview
}

export const ProjectPreview: React.FC<IProjectPreviewProps> = (props) => {
    return (
        <div>
            <Link to={`/projects/details/${props.obj.shortName}`}>{props.obj.projectTitle}</Link>
        </div>
    )
}