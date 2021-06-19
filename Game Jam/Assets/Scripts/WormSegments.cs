using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts_2
{
    public class WormSegments: MonoBehaviour
    {
        public static WormSegments Instance;
        public int MaxSegments;
        public Transform SegmentTransform;
        public GameObject SegmentPrefab;
        public int Segments;
        private GameObject _previousSegment;
        public int MaxOrder;
        public float Timer;
        private float _timer;
        private bool attacked;
        
        [SerializeField] private List<GameObject> _segments;


        private void Start(){
            Instance = this;
            Initialize();
        }

        private void Update(){
            if (attacked == false) return;
            _timer += Time.deltaTime;

            if (_timer >= Timer){
                attacked = false;
            }
        }


        public void AddSegment(){
            var newSegment = Instantiate(SegmentPrefab, SegmentTransform);
            _segments.Add(newSegment);
            newSegment.GetComponentInChildren<SpriteRenderer>().sortingOrder = _segments[_segments.Count - 2].GetComponentInChildren<SpriteRenderer>().sortingOrder - 1;
            newSegment.GetComponent<HingeJoint2D>().connectedBody = _segments[_segments.Count - 2].GetComponent<Rigidbody2D>();
            newSegment.transform.position = _segments[_segments.Count - 2].transform.position;
            newSegment.transform.rotation = _segments[_segments.Count - 2].transform.rotation;
            // newSegment.transform.position = new Vector3(transform.position.x + 2, transform.position.y, 0);
            newSegment.GetComponent<HingeJoint2D>().connectedAnchor = Vector2.zero;
        }


        void Initialize(){
            _segments.Add(SegmentTransform.GetChild(0).gameObject);
            for (int i = 1; i < SegmentTransform.childCount; i++){
                var segment = SegmentTransform.GetChild(i);
                segment.GetComponent<HingeJoint2D>().connectedBody = SegmentTransform.GetChild(i - 1).GetComponent<Rigidbody2D>();
                segment.GetComponentInChildren<SpriteRenderer>().sortingOrder = MaxOrder--;
                _segments.Add(segment.gameObject);
            }
        }

        public void TryAddSegment(){
            if (_segments.Count == MaxSegments) return;
            AddSegment();
        }

        public void DestroySegment(){
            if (attacked) return;

            attacked = true;
            Destroy(_segments[_segments.Count - 1]);
            _segments.Remove(_segments[_segments.Count - 1]);
        }


    }


}
