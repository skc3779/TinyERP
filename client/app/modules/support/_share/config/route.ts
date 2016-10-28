let route = {
    support: {
        requests: { name: "Requests", path: "/support/requests" },
        createRequest: { name: "Create Request", path: "/support/createRequest" },
        createRequestConfirmation: { name: "Create Request Confirmation", path: "/support/createRequestConfirmation" },
        viewRequest: { name: "View Request", path: "/support/request/:id" },
    }
};
export default route;