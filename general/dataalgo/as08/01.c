#include <stdio.h>
#include <stdlib.h>

typedef struct _TreeNode {
    int data;
    struct _TreeNode *left;
    struct _TreeNode *right;
} TreeNode;

typedef struct _BST {
    TreeNode *root;
} BST;

TreeNode *newNode(int item);

void inorder(TreeNode *n);
void postorder(TreeNode *n);
void preorder(TreeNode *n);

void init(BST *tree);
void insert(BST *tree, int item);
int search(BST *tree, int item);

int min(BST *tree);
int max(BST *tree);
int count(BST *tree);

int main() {

    BST tree;
    BST *t = &tree;
    init(t);
    insert(t, 7);
    insert(t, 4);
    insert(t, 10);
    insert(t, 3);
    insert(t, 6);
    insert(t, 1);
    insert(t, 5);
    insert(t, 9);
    insert(t, 12);

    printf("\nInOrder\n");
    inorder(t->root);

    printf("\nPostOrder\n");
    postorder(t->root);

    printf("\nPreOrder\n");
    preorder(t->root);

    printf("\nMIN: %d\n", min(t));
    printf("\nMAX: %d\n", max(t));

    printf("\nCOUNT: %d\n", count(t));

    return 0;
}

TreeNode *newNode(int item) {
    TreeNode *tmp = (TreeNode *) malloc(sizeof(TreeNode));
    tmp->data = item;
    tmp->left = tmp->right = NULL;
}

void inorder(TreeNode *n) {
    if(n == NULL) return;
    if(n->left != NULL) inorder(n->left);
    printf("%d\n", n->data);
    if(n->right != NULL) inorder(n->right);
}

void postorder(TreeNode *n) {
    if(n == NULL) return;
    if(n->left != NULL) inorder(n->left);
    if(n->right != NULL) inorder(n->right);
    printf("%d\n", n->data);
}
void preorder(TreeNode *n) {
    if(n == NULL) return;
    printf("%d\n", n->data);
    if(n->left != NULL) inorder(n->left);
    if(n->right != NULL) inorder(n->right);
}

void init(BST *tree) {
    tree->root = NULL;
}

void insert(BST *tree, int item) {
    TreeNode *p = tree->root;
    TreeNode *t = newNode(item);
    TreeNode *c = p;
    if(search(tree, item) == 1) {
	printf("Error: %d already exists in tree\n", item);
	return;
    }
    if(p == NULL) {
	tree->root = t;
	return;
    }
    while(c != NULL) {
	p = c;
	if(item < c->data) {
	    c = c->left;
	    if(c == NULL) {
		p->left = t;
	    }
	} else {
	    c = c->right;
	    if(c == NULL) {
		p->right = t;
	    }
	}
    }
}

int search(BST *tree, int item) {
    TreeNode *p = tree->root;
    TreeNode *c = p;
    if(p == NULL)
	return 0;
    if(c->data == item)
	return 1;
    while(c != NULL) {
	p = c;
	if(item < c->data)
	    c = c->left;
	else
	    c = c->right;
	if(c != NULL && c->data == item)
	    return 1;
    }
    return 0;
}

int min(BST *tree) {
    TreeNode *c = tree->root;
    if(c == NULL) {
	printf("No Root Node!\n");
	return -1;
    }
    while(c->left != NULL) {
	c = c->left;
    }
    return c->data;
}

int max(BST *tree) {
    TreeNode *c = tree->root;
    if(c == NULL) {
	printf("No Root Node!\n");
	return -1;
    }
    while(c->right != NULL) {
	c = c->right;
    }
    return c->data;
}

int _count(TreeNode *n) {
    int t = 0;
    if(n == NULL) return 0;
    t += 1;
    if(n->left != NULL)
	t += _count(n->left);
    if(n->right != NULL)
	t += _count(n->right);
    return t;
}

int count(BST *tree) {
    return _count(tree->root);
}
