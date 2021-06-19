import React, { useState, useEffect } from "react";
import { Form, Formik, Field, ErrorMessage } from "formik";
import * as Yup from "yup";

import { createUserProject } from "./utils";
import { ICreateProjectRequest, ICreateProjectResponse } from "../../../shared/interfaces";

export const CreateUserProject: React.FC = () => {
    const initialValues: ICreateProjectRequest = { title: "", description: "" };
    const [responseResult, setResponseResult] = useState<ICreateProjectResponse>({
        id: -1,
        title: "",
        description: "",
        dateCreated: new Date(),
        isSuccess: true,
        errors:[]
    });

    return (
        <div>
            <Formik initialValues={initialValues}
                onSubmit={(request) => {
                    createUserProject(request)}}
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
    description: Yup.string()
        .max(255, "Description must be shorter than 255 characters.")
});