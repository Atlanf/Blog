import React, { useState } from "react";
import { Form, Formik, Field, ErrorMessage } from "formik";
import * as Yup from "yup";

import { createUserProject } from "./utils";
import { ICreateProjectRequest, ICreateProjectResponse } from "../../../shared/interfaces";

export const CreateUserProject: React.FC = () => {
    const initialValues: ICreateProjectRequest = { title: "", shortName: "", description: "" };
    const [responseResult, setResponseResult] = useState<ICreateProjectResponse>({
        id: -1,
        title: "",
        shortName: "",
        description: "",
        dateCreated: new Date(),
        isSuccess: true,
        errors:[]
    });

    return (
        <div>
            <Formik initialValues={initialValues}
                onSubmit={async (request) => {
                    setResponseResult(await createUserProject(request))}}
                validationSchema={createUserProjectValidationSchema}
            >
                {({errors, touched}) => (
                    <Form>
                        { responseResult.isSuccess ? null : (
                            <div>{responseResult.errors}</div>
                        )}

                        <label htmlFor="title" title="Project title" />
                        <Field type="text" name="title" placeholder="Enter project title" />
                        { errors.title && touched.title ? (
                            <div>{errors.title}</div>
                        ): null}
                        <ErrorMessage name="title" />
                        
                        <label htmlFor="shortName" title="Short name" />
                        <Field type="text" name="shortName" placeholder="Enter short project name" />
                        { errors.shortName && touched.shortName ? (
                            <div>{errors.shortName}</div>
                        ): null}

                        <label htmlFor="description" title="Project description" />
                        <Field type="text" name="description" placeholder="Enter project description (optional)" />
                        { errors.description && touched.title ? (
                            <div>{errors.description}</div>
                        ): null}
                        <ErrorMessage name="description" />

                        <button type="submit">Create</button>
                    </Form>
                )}
            </Formik>
        </div>
    )
}

const createUserProjectValidationSchema = Yup.object().shape({
    title: Yup.string()
        .min(10, "Title must be at least 10 characters.")
        .max(50, "Title must be shorter than 50 characters.")
        .required("Required"),
    shortName: Yup.string()
        .min(5, "Name must be at least 5 characters.")
        .max(25, "Name must be shorter than 25 characters."),
    description: Yup.string()
        .max(255, "Description must be shorter than 255 characters.")
});