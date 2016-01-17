using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UbwTools.Common.Storage;
using UbwTools.Sql.Gui;

namespace UbwTools.Sql
{
    public class FavoritesManager
    {
        private static FavoritesManager _instance;
        public static FavoritesManager Instance
        {
            get { return _instance ?? (_instance = new FavoritesManager()); }
        }

        private FavoritesManager()
        {
        }

        private TreeNode _favoritesTree;
        private TreeNode _favoriteTables;
        private TreeNode _favoriteViews;
        private TreeNode _favoriteSqls;

        public void PrepareFavoritesPane()
        {
            SqlCommon.SqlForm.treeFavorites.BeginUpdate();
            SqlCommon.SqlForm.treeFavorites.Nodes.Clear();
            SqlCommon.SqlForm.treeFavorites.Nodes.Add(_favoritesTree = new NodeRoot("Favoritter", SqlGuiForm.IconFavorites));
            _favoritesTree.Nodes.Add(_favoriteTables = new NodeFolder("Tabeller"));
            _favoritesTree.Nodes.Add(_favoriteViews = new NodeFolder("Views"));
            _favoritesTree.Nodes.Add(_favoriteSqls = new NodeFolder("SQL-uttrykk"));
            _favoritesTree.ExpandAll();
            SqlCommon.SqlForm.treeFavorites.EndUpdate();
        }

        public void AddFavoriteTable(string name)
        {
            NodeFavoriteTable node = ExistingFavoriteTable(name);
            if (null == node)
            {
                node = new NodeFavoriteTable(name, SqlCommon.SqlForm.contextFavoriteTable);
                _favoriteTables.Nodes.Add(node);
            }
            SqlCommon.SqlForm.treeFavorites.SelectedNode = node;
        }

        public void AddFavoriteView(string name)
        {
            NodeFavoriteView node = ExistingFavoriteView(name);
            if (null == node)
            {
                node = new NodeFavoriteView(name, SqlCommon.SqlForm.contextFavoriteView);
                _favoriteViews.Nodes.Add(node);
            }
            SqlCommon.SqlForm.treeFavorites.SelectedNode = node;
        }

        private NodeFavoriteTable ExistingFavoriteTable(string name)
        {
            return ExistingFavorite(_favoriteTables, name) as NodeFavoriteTable;
        }

        private NodeFavoriteView ExistingFavoriteView(string name)
        {
            return ExistingFavorite(_favoriteViews, name) as NodeFavoriteView;
        }

        private TreeNode ExistingFavorite(TreeNode categoryRoot, string name)
        {
            foreach (TreeNode node in categoryRoot.Nodes)
            {
                if (name.Equals(node.Text, StringComparison.OrdinalIgnoreCase))
                {
                    return node;
                }
            }
            return null;
        }

        public void RemoveFavoriteTable(NodeFavoriteTable node)
        {
            node.Remove();
        }

        public void RemoveFavoriteView(NodeFavoriteView node)
        {
            node.Remove();
        }

        public void Save()
        {
            Repository.Sql.Favorites.Tables.ClearAndSaveList(ChildNodesToList(_favoriteTables));
            Repository.Sql.Favorites.Views.ClearAndSaveList(ChildNodesToList(_favoriteViews));
            Repository.Sql.Favorites.Statements.ClearAndSaveList(ChildNodesToList(_favoriteSqls));
        }

        private IEnumerable<string> ChildNodesToList(TreeNode parent)
        {
            List<string> result = new List<string>();
            foreach (TreeNode node in parent.Nodes)
            {
                result.Add(node.Text);
            }
            return result;
        }

        public void Load()
        {
            LoadFavoriteTables();
            LoadFavoriteViews();
            LoadFavoriteStatements();
        }

        private void LoadFavoriteTables()
        {
            List<string> names = Repository.Sql.Favorites.Tables.GetValueNames().ToList();
            names.Sort();
            foreach (string name in names)
            {
                NodeFavoriteTable node = new NodeFavoriteTable(name, SqlCommon.SqlForm.contextFavoriteTable);
                _favoriteTables.Nodes.Add(node);
            }
        }

        private void LoadFavoriteViews()
        {
            List<string> names = Repository.Sql.Favorites.Views.GetValueNames().ToList();
            names.Sort();
            foreach (string name in names)
            {
                NodeFavoriteView node = new NodeFavoriteView(name, SqlCommon.SqlForm.contextFavoriteView);
                _favoriteViews.Nodes.Add(node);
            }
        }

        private void LoadFavoriteStatements()
        {
            // TODO
        }

        //public void AddFavoriteIfNotAlreadyExisting(NodeTableViewBase newFavoriteSource)
        //{
        //    NodeDatabaseTable sourceTable = newFavoriteSource as NodeDatabaseTable;
        //    if (null != sourceTable)
        //    {
        //        AddFavoriteTable(sourceTable.Text);
        //    }
        //    else
        //    {
        //        NodeDatabaseView sourceView = newFavoriteSource as NodeDatabaseView;
        //        if (null != sourceView)
        //        {
        //            AddFavoriteView(sourceView.Text);
        //        }
        //    }
        //}
    }
}
