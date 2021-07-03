import React from "react";
import { Navbar, Nav } from "react-bootstrap";

export const NavBar = () => {
    return (
        <Navbar bg="dark" variant="dark">
            <Navbar.Brand href="">Blog</Navbar.Brand>
            <Nav className="mr-auto">
                <Nav.Link href="/">Home</Nav.Link>
                <Nav.Link href="/projects">Projects</Nav.Link>
            </Nav>
        </Navbar>
    );
}