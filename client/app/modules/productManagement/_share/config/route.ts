let route = {
    productManagement: {
        categories: { name: "Categories", path: "/categories" },
        addCategory: { name: "Add Category", path: "/addCategory" },
        editCategory: { name: "Edit Category", path: "/editCategory/:id" },

        products: { name: "Products", path: "/products" },
        addProduct: { name: "Add Product", path: "/addProduct" },
        editProduct: { name: "Edit Product", path: "/editProduct/:id" },
    }
};
export default route;