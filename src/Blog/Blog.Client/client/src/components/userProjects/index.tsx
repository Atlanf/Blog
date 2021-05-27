import React, { useState, useEffect } from "react";
import { getUserProjects } from "./api";
import { ProjectPreview } from "./projectPreview";

import { IProjectPreviews, IPaginatedList, IUserProjectPreview } from "../../shared/interfaces";

const userName = "admin";

export const UserProjects: React.FC = () => {
    const [projects, setProjects] = useState<IProjectPreviews>({
        userProjectPreviews: {
            items: Array<IUserProjectPreview>()
        } as IPaginatedList<IUserProjectPreview>, error: false})
    
    useEffect(() => {
        async function fetchApi() {
            setProjects(await getUserProjects(userName));
        }

        fetchApi();
    }, []);

    return (
        <div>
            {projects.userProjectPreviews.items.map((proj) => {
                return (
                    <ProjectPreview obj={proj}>
                    </ProjectPreview>
                )
            })}
        </div>
    )
}