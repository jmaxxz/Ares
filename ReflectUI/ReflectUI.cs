/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009-2010  Jmaxxz, Mike McBride, and Kevin Curtis
 * 
 * This file is under the the following License
 *          DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *                   Version 2, December 2004
 *       Copyright (C) 2004 Sam Hocevar <sam@hocevar.net>
 *
 *       Everyone is permitted to copy and distribute verbatim or modified
 *       copies of this license document, and changing it is allowed as long
 *       as the name is changed.
 *
 *                  DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *         TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
 *
 *          0. You just DO WHAT THE FUCK YOU WANT TO.
 *  
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Fully implemented
 * 1.0      jmaxxz Added support for collections      Collections can not be reflected
 */
namespace Ares.Common.ReflectUI
{
    using System.Windows.Forms;
    using System.Collections;
    using System.Reflection;
    using System.Linq;
    using System;

    /// <summary>
    /// A tree bases user control which shows the reflected state of an object
    /// </summary>
    public partial class ReflectUI : UserControl
    {
        /// <summary>
        /// The object which this control reflects
        /// </summary>
        public object Subject { get; set; }
        

        /// <summary>
        /// Creates a new instance which reflects a specified user control.
        /// </summary>
        /// <param name="o"></param>
        public ReflectUI(object o)
        {
            Subject = o;
            InitializeComponent();
            UpdateView();
        }

        /// <summary>
        /// Creates a new instance which has a null <see cref="Subject"/>
        /// </summary>
        public ReflectUI() :this(null) 
        {
        }

        /// <summary>
        /// Prevents repainting, to allow for faster updates
        /// </summary>
        public void BeginUpdate()
        {
            ReflectionTree.BeginUpdate();
        }

        /// <summary>
        /// Resumes repainting
        /// </summary>
        public void EndUpdate()
        {
            ReflectionTree.EndUpdate();
        }

        /// <summary>
        /// Expands all nodes
        /// </summary>
        public void ExpandAll()
        {
            ReflectionTree.ExpandAll();
        }

        /// <summary>
        /// Rebuilds tree based on the current state of <see cref="Subject"/>
        /// </summary>
        public void UpdateView()
        {
            ReflectionTree.Nodes.Clear();
            ReflectionTree.Nodes.Add(CreateNodeFor(new ReflectedProperty("Subject", Subject)));


        }

        /// <summary>
        /// Creates a new node for a specified property
        /// </summary>
        /// <param name="property">The property from which a node should be created</param>
        /// <returns>A representation of the passed in property as a <see cref="TreeNode"/></returns>
        private TreeNode CreateNodeFor(ReflectedProperty property)
        {
            //Return early if value is null
            if (property.Value == null)
            {
                return new TreeNode(property.Name + ": null");
            }

            TreeNode node = new TreeNode(property.Name + ": "+ property.ValueAsString);

            //Return early if value is primative
            Type type = property.ValueTypeOf;
            if (type.IsPrimitiveLike())
            {
                return node;
            }

            IEnumerable enumerable = property.Value as IEnumerable;

            if (enumerable != null)
            {
                int i = 0;
                foreach(var v in enumerable)
                {
                    ReflectedProperty childProperty = new ReflectedProperty(i.ToString(), v);
                    TreeNode child = new TreeNode { Tag = childProperty };
                    node.Nodes.Add(child);
                    i++;
                }
            }




            //In the complex case we need to recursively call this methods and build up nodes for all child properties
            PropertyInfo[] properties = property.ValueTypeOf.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                ReflectedProperty childProperty = new ReflectedProperty(propertyInfo, property.Value);

                //rely on lazy loading of tree to prevent infinite loops
                TreeNode child = new TreeNode {Tag = childProperty};
                node.Nodes.Add(child);
            }


            return node;
        }

        private void ReflectionTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode[] children = (from TreeNode child in e.Node.Nodes select CreateNodeFor((ReflectedProperty) child.Tag)).ToList().ToArray();

            e.Node.Nodes.Clear();
            e.Node.Nodes.AddRange(children);
        }


    }
}