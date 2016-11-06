let route = {
    store: {
        accounts: { name: "Accounts", path: "/accounts" },
        addAccount: { name: "Add Account", path: "/addAccount" },
        editAccount: { name: "Edit Account", path: "/editAccount/:id" },

        stores: { name: "Stores", path: "/stores" },
        addStore: { name: "Add Store", path: "/addStore" },
        editStore: { name: "Edit Store", path: "/editStore/:id" },

        orders: { name: "Orders", path: "/orders" },
        viewOrder: { name: "View Order", path: "/viewOrder/:id" },
    }
};
export default route;