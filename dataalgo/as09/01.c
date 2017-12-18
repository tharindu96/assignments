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

void inorder(TreeNode *n);
void postorder(TreeNode *n);
void preorder(TreeNode *n);

void init(BST *tree);
void insert(BST *tree, int item);
int search(BST *tree, int item);

int min(BST *tree);
int max(BST *tree);
int count(BST *tree);

int delete(BST *tree, int item);

int sum(BST *tree);

void displayLeaf(BST *tree);

void displayLessThan(BST *tree, int value);

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

    delete(t, 12);
    delete(t, 10);
    delete(t, 7);

    insert(t, 20);
    insert(t, 30);
    insert(t, 25);
    insert(t, 27);
    insert(t, 31);

    printf("\nInOrder\n");
    inorder(t->root);

    printf("\nPostOrder\n");
    postorder(t->root);

    printf("\nPreOrder\n");
    preorder(t->root);

    printf("\nMIN: %d\n", min(t));
    printf("\nMAX: %d\n", max(t));

    printf("\nCOUNT: %d\n", count(t));

    printf("\nSUM: %d\n", sum(t));

    printf("\nLeaf Nodes\n");
    displayLeaf(t);

    printf("\nLess than 25");
    displayLessThan(t, 25);

    return 0;
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

    TreeNode *t = (TreeNode *) malloc(sizeof(TreeNode));
    t->data = item;
    t->left = NULL;
    t->right = NULL;
    
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

int _delete(BST *tree, TreeNode *n, TreeNode *p) {
    if(n == NULL) return 0;
    int c = 0;
    if(n->left != NULL) c++;
    if(n->right != NULL) c++;
    TreeNode *t;
    TreeNode *tp;
    switch(c) {
    case 0:
    	if(p != NULL) {
    	    if(p->left == n) {
    		p->left = NULL;
    	    } else {
    		p->right = NULL;
    	    }
    	} else {
    	    tree->root = NULL;
    	}
    	free(n);
    	break;
    case 1:
    	if(n->left != NULL) t = n->left;
    	if(n->right != NULL) t = n->right;
    	if(p != NULL) {
    	    if(p->left == n) {
    		p->left = t;
    	    } else {
    		p->right = t;
    	    }
    	} else {
    	    tree->root = t;
    	}
    	free(n);
    	break;
    case 2:
	
        // get the minimum element of the right sub tree (successor)
	tp = n;
	t = tp->right;
	while(t->left != NULL) {
	    tp = t;
	    t = t->left;
	}

    	int temp = n->data;
    	n->data = t->data;
    	t->data = temp;
    	return _delete(tree, t, tp);
    	break;
    }
    return 1;
}

int delete(BST *tree, int item) {
    if(search(tree, item) == 0)
	return 0;
    TreeNode *p, *n;
    n = tree->root;
    while(n->data != item) {
	p = n;
	if(item < n->data)
	    n = n->left;
	else
	    n = n->right;
    }
    return _delete(tree, n, p);
}

int _sum(TreeNode *n) {
    if(n == NULL) return 0;
    int s = n->data;
    s += _sum(n->left);
    s += _sum(n->right);
    return s;
}

int sum(BST *tree) {
    return _sum(tree->root);
}

void _displayLeaf(TreeNode *n) {
    if(n == NULL) return;
    if(n->left == NULL && n->right == NULL) {
	printf("%d\n", n->data);
	return;
    }
    _displayLeaf(n->left);
    _displayLeaf(n->right);
}

void displayLeaf(BST *tree) {
    _displayLeaf(tree->root);
}

int _inorderLess(BST *tree, int value) {
    
}

void displayLessThan(BST *tree, int value) {
    if(search(tree, value) == 0) {
	printf("value not in the tree!\n");
	return;
    }

    
}
