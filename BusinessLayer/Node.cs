using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMOntology.BusinessLayer
{
    class Node
    {
        public static int GetNodeIndex(CommonTools.NodeCollection coll, CommonTools.Node node)
        {
            int index = 0;
            CommonTools.Node tmp = coll.FirstNode;            

            while (tmp != null && !CRMOntology.BusinessLayer.Node.Equals(tmp,node))
            {
                if (tmp.Nodes.Count > 0)
                {
                    int recursive = CRMOntology.BusinessLayer.Node.GetNodeIndex(tmp.Nodes, node);
                    if (recursive >= 0)
                        return index;
                }
                tmp = tmp.NextSibling;
                index++;
            }
            if (tmp == null)
                return -1;
            return index;
        }

        public static int GetNodeIndex(CommonTools.NodeCollection coll, object key)
        {
            int index = 0;
            CommonTools.Node tmp = coll.FirstNode;
            while (tmp != null && !CRMOntology.BusinessLayer.Node.Equals(tmp, key))
            {
                if (tmp.Nodes.Count > 0)
                {
                    int recursive = CRMOntology.BusinessLayer.Node.GetNodeIndex(tmp.Nodes, key);
                    if (recursive >= 0)
                        return recursive;
                }
                tmp = tmp.NextSibling;
                index++;
            }
            if (tmp == null)
                return -1;
            return index;
        }


        public static bool Equals(CommonTools.Node SourceNode, CommonTools.Node TargetNode)
        {
            if (SourceNode.GetDataLength == TargetNode.GetDataLength)
            {
                for (int i = 0; i<SourceNode.GetDataLength; i++)
                {
                    if (!SourceNode[i].Equals(TargetNode[i]))
                        return false;
                }
                return true;
            }
            else
                return false;

        }

        public static bool Equals(CommonTools.Node SourceNode, object key)
        {
            for (int i = 0; i < SourceNode.GetDataLength; i++)
            {
                if (SourceNode[i].Equals(key))
                    return true;
            }
            return false;
        }
         
    }
}
