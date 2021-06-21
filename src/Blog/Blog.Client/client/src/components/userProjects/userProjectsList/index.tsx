import React, { useState, useEffect } from "react";
import { getUserProjects } from "./api";
import { ProjectPreview } from "./projectPreview";

import { IProjectPreviews, IPaginatedList, IUserProjectPreview } from "../../../shared/interfaces";

import { LoadingSpinner } from "../../loadingSpinner";

const userName = "admin";

export const UserProjects: React.FC = () => {
    const [projects, setProjects] = useState<IProjectPreviews>({
        userProjectPreviews: {
            items: Array<IUserProjectPreview>()
        } as IPaginatedList<IUserProjectPreview>, error: false, isLoading: true})
    
    useEffect(() => {
        async function fetchApi() {
            setProjects(await getUserProjects(userName));
        }

        fetchApi();
    }, []);

    if (projects.isLoading) {
        return (
            <LoadingSpinner />
        )
    }
    else if (projects.error) {
        return (
            <div>

            </div>
        )
    }
    else {
        return (
            <div>
                {projects.userProjectPreviews.items.map((proj) => {
                    return (
                        <ProjectPreview obj={proj} />
                    )
                })}
            </div>
        )
    }
}