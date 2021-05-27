import { IPaginatedList } from "./index";

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
    error: boolean
}