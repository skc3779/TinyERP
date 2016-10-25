let route = {
    permission: {
        permissions: { name: "Permissions", path: "/security/permissions" },
        addPermission: { name: "Add Permission", path: "/security/addPermission" },
        editPermission: { name: "Edit Permission", path: "/security/editPermission/:id" }
    },
    role: {
        roles: { name: "Roles", path: "/security/roles" },
        addRole: { name: "Add Role", path: "/security/addRole" },
        editRole: { name: "Edit Role", path: "/security/editRole/:id" }
    },
    userGroup: {
        userGroups: { name: "UserGroups", path: "/security/userGroups" },
        addUserGroup: { name: "Add UserGroup", path: "/security/addUserGroup" },
        editUserGroup: { name: "Edit UserGroup", path: "/security/editUserGroup/:id" }
    }
};
export default route;