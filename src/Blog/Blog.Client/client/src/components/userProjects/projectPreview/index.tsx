import React from "react";

import { IUserProjectPreview } from "../../../shared/interfaces";

interface IProjectPreviewProps {
    obj: IUserProjectPreview
}

export const ProjectPreview: React.FC<IProjectPreviewProps> = (props) => {
    return (
        <div>
            {props.obj.projectTitle}
        </div>
    )
}