import { IPaginatedList, IBaseResponse } from "./index";

export interface IUserProjectPreview {
    id: number,
    projectTitle: string,
    priorityRatio: number,
    highPriorityTaskCount: number,
    unfinishedTasks: number,
    lastFinishedTask: Date
}

export interface IProjectPreviews {
    userProjectPreviews: IPaginatedList<IUserProjectPreview>,
    error: boolean,
    isLoading: boolean
}

export interface ICreateProjectRequest {
    title: string,
    description: string
}

export interface ICreateProjectResponse extends IBaseResponse {
    id: number,
    title: string,
    description: string,
    dateCreated: Date
}

export interface IUserProjectDetails {
    
}