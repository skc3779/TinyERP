let route = {
    setting: {
        contentTypes: { name: "ContentTypes", path: "/setting/contenttypes" },
        addContentType: { name: "AddContentTypes", path: "/setting/addcontenttypes" },
        editContentType: { name: "EditContentTypes", path: "/setting/editcontenttypes/:id" }
    }
};
export default route;